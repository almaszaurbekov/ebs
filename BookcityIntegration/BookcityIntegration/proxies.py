from random import choice
from bs4 import BeautifulSoup
from fake_useragent import UserAgent

def proxy_init():
    proxies = []
    with open("BookcityIntegration/proxies.content.txt", "r") as proxy_file:
        soup = BeautifulSoup(proxy_file.read(), 'html.parser')
        tr = soup.findAll('td', attrs={'class': 'tdl'})
        for td in tr:
            proxies.append(td.text)
    return proxies

def get_proxy():
    return {"http//": choice(proxies)}

def get_user_agent():
    return {"User-Agent": UserAgent().chrome}

proxies = proxy_init()