#!flask/bin/python
from flask import Flask, jsonify
from functions import *

app = Flask(__name__)

@app.route('/ebs/test', methods=['GET'])
def test():
    return jsonify("200 OK")

@app.route('/ebs/bookcity/<string:book>', methods=['GET'])
def bookcity_search(book):
    return jsonify(bookcity_parse(book))

@app.route('/ebs/amazon/<string:book>', methods=['GET'])
def amazon_search(book):
    return jsonify(amazon_parse(book))

@app.route('/ebs/isbn/<string:book>', methods=['GET'])
def isbn_search(book):
    return jsonify(isbn_parse(book))

if __name__ == '__main__':
    app.run(debug=True)