import requests
from random import choice
from bs4 import BeautifulSoup
import os

def proxy_init():
    proxies = []
    proxy_file = open("proxies.content.txt", "r")
    soup = BeautifulSoup(proxy_file.read(), 'html.parser')
    tr = soup.findAll('td', attrs={'class': 'tdl'})
    for td in tr:
        proxies.append(td.text)
    proxy_file.close()
    return proxies

def get_proxy():
    return {"http//": choice(proxies)}

def get_user_agent():
    return {"User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.117 Safari/537.36"}

def bookcity_parse(word):
    url = "https://www.bookcity.kz/search/?SORTBY=RELEVANSE&q={}".format(word)
    main_url = "https://www.bookcity.kz/{}"

    page = requests.get(url, headers=get_user_agent(), proxies=get_proxy())
    soup = BeautifulSoup(page.content, 'html.parser')

    links = soup.findAll('a', attrs={'class': 'product-card__link'})
    titles = soup.findAll('div', attrs={'class': 'product-card-title'})
    authors = soup.findAll('div', attrs={'class': 'product-card-author'})
    images = soup.findAll('img', attrs={'class':'js-lazy'})

    result = []
    for i in range(len(links)):
        result.append(
            {
                'href'   : main_url.format(links[i]['href']),
                'title'  : titles[i].text,
                'author' : authors[i].text,
                'image'  : images[i]['data-src']
            }
        )
    return result

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

proxies = proxy_init()
print(amazon_parse('python'))