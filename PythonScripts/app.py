from flask import Flask, jsonify
from flask_cors import CORS, cross_origin
from bc import *

app = Flask(__name__)
app.config['SECRET_KEY'] = 'the quick brown fox jumps over the lazy dog'
app.config['CORS_HEADERS'] = 'Content-Type'
CORS(app)

@app.route('/')
def index():
    return "<h1>Hello world</h1>"

@app.route('/ebs/test', methods=['GET'])
def test():
    return jsonify("200 OK")

@app.route('/ebs/bookcity/<string:book>', methods=['GET'])
def bookcity_search(book):
    return jsonify(bookcity_parse(book))

@app.route('/ebs/bookcity/details/<string:url>', methods=['GET'])
def bookcity_search_details(url):
    return jsonify(bookcity_parse_details(url))

# @app.route('/ebs/amazon/<string:book>', methods=['GET'])
# def amazon_search(book):
#     return jsonify(amazon_parse(book))
#
# @app.route('/ebs/isbn/<string:book>', methods=['GET'])
# def isbn_search(book):
#     return jsonify(isbn_parse(book))

if __name__ == '__main__':
    app.run(debug=True)