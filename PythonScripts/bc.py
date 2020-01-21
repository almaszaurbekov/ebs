from base_functions import *
from bs4 import BeautifulSoup
import requests
import json

def bookcity_parse(word):
    url = "https://www.bookcity.kz/search/?SORTBY=RELEVANSE&q={}".format(word)

    page = requests.get(url, headers=get_user_agent(), proxies=get_proxy())
    soup = BeautifulSoup(page.content, 'html.parser')

    links = soup.findAll('a', attrs={'class': 'product-card__link'})
    titles = soup.findAll('div', attrs={'class': 'product-card-title'})
    authors = soup.findAll('div', attrs={'class': 'product-card-author'})
    images = soup.findAll('img', attrs={'class':'js-lazy'})

    result = []
    for i in range(len(links)):
        author = None
        try:
            author = authors[i].text
        except:
            pass
        result.append(
            {
                'href'   : links[i]['href'].split('/')[2],
                'title'  : titles[i].text,
                'author' : author,
                'image'  : images[i]['data-src']
            }
        )
    return result

def bookcity_parse_details(url):
    main_url = "https://www.bookcity.kz/products/{}/".format(url)
    page = requests.get(main_url, headers=get_user_agent(), proxies=get_proxy())
    soup = BeautifulSoup(page.content, 'html.parser')

    print({
        'title': bc_title(soup),
        'image': bc_image(soup),
        'desc': bc_desc(soup),
        'author': bc_author(soup)
    })

    return {
        'title': bc_title(soup),
        'image': bc_image(soup),
        'desc': bc_desc(soup),
        'author': bc_author(soup)
    }

def bc_title(soup):
    try:
        obj = soup.find('h1', attrs={'class': 'page-title'})
        return (obj.text).strip()
    except:
        return None

def bc_image(soup):
    try:
        obj = soup.find('img', attrs={'class': 'picture-glass'})
        return obj['src']
    except:
        return None

def bc_desc(soup):
    try:
        obj = soup.find('div', attrs={'class': 'shave-descr js-shave'})
        return (obj.text).strip()
    except:
        return None

def bc_author(soup):
    try:
        obj = soup.find('div', attrs={'class': 'catalog-item-author hidden-sm'})
        obj = obj.find('a')
        return (obj.text).strip()
    except:
        return None