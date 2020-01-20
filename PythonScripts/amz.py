from base_functions import *
from bs4 import BeautifulSoup
import requests
import os

def amazon_parse(word):
    url = 'https://www.amazon.com/s?k={}&i=stripbooks-intl-ship&ref=nb_sb_noss_2'.format(word)
    main_url = 'https://www.amazon.com{}'
    files, links, titles, authors, images = [], [], [], [], []
    temp, const_number = 0, 50000
    page = requests.get(url, headers=get_user_agent(), proxies=get_proxy())
    decoded_content = page.content.decode("utf-8")
    for i in range(len(decoded_content) // const_number):
        file = 'page-{}.txt'.format(i)
        with open(file, 'w', encoding="utf-8") as wr:
            for j in range(const_number):
                wr.write(decoded_content[temp + j])
            temp += const_number
        files.append(file)

    for file in files:
        with open(file, 'r', encoding="utf-8") as rd:
            soup = BeautifulSoup(rd.read(), 'html.parser')
            for l in soup.findAll('a', attrs={'class': 'a-link-normal a-text-normal'}):
                links.append(main_url.format(l['href']))
            for t in soup.findAll('span', attrs={'class': 'a-size-medium a-color-base a-text-normal'}):
                titles.append(t.text)
            for a in soup.findAll('a', attrs={'class': 'a-size-base a-link-normal'}):
                authors.append((a.text).strip())
            for i in soup.findAll('img', attrs={'class': 's-image'}):
                images.append(i['src'])

        os.remove(file)

    result = []
    for i in range(len(links)):
        try:
            result.append(
                {
                    'href'  : main_url.format(links[i]),
                    'title' : titles[i],
                    'author': authors[i],
                    'image' : images[i]
                }
            )
        except:
            pass
    return result