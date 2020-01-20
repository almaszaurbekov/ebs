from random import choice
from bs4 import BeautifulSoup

def proxy_init():
    proxies = []
    with open("proxies.content.txt", "r") as proxy_file:
        proxy_file = open("proxies.content.txt", "r")
        soup = BeautifulSoup(proxy_file.read(), 'html.parser')
        tr = soup.findAll('td', attrs={'class': 'tdl'})
        for td in tr:
            proxies.append(td.text)
    return proxies

def get_proxy():
    return {"http//": choice(proxies)}

def get_user_agent():
    return {"User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.117 Safari/537.36"}

proxies = proxy_init()