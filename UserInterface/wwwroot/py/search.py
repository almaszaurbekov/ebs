import requests
from bs4 import BeautifulSoup

url = "https://www.bookcity.kz/search/?SORTBY=RELEVANSE&q={}".format(word.replace(' ', '+'))
main_url = "https://www.bookcity.kz/{}"
headers = {"User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.117 Safari/537.36"}
page = requests.get(url, headers)
soup = BeautifulSoup(page.content, 'html.parser')
links = soup.findAll('a', attrs={'class' : 'product-card__link'})
for link in links:
	print(main_url.format(link['href']))