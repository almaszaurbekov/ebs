from base_functions import *
from bs4 import BeautifulSoup
import requests

def isbn_parse(isbn):
    if(len(str(isbn)) == 13 and check_ean13(str(isbn)) == 0):
        url = "https://www.triumph.ru/html/serv/find-isbn.php?isbn={}".format(isbn)
        page = requests.get(url, headers=get_user_agent(), proxies=get_proxy())
        soup = BeautifulSoup(page.content, 'html.parser')
        return { "result": soup }
    return { "result":None }

def check_ean13(value):
    kof = [1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1]
    sum = 0
    for i in range(13):
        sum += ord(value[i]) * kof[i]
    return (sum % 10)