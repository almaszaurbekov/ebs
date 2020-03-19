from flask import Flask, jsonify, render_template
from flask_cors import CORS, cross_origin
from bc import *

app = Flask(__name__)
app.config['SECRET_KEY'] = 'the quick brown fox jumps over the lazy dog'
app.config['CORS_HEADERS'] = 'Content-Type'
CORS(app)

@app.route('/')
def index():
    lev = {
        "db": 2004,
        "name": "Lev",
        "height": 170,
        "weight": 70
    }

    almas = {
        "db": 1999,
        "name": "Almas",
        "height": 170,
        "weight": 65
    }

    persons = [lev, almas]

    return render_template('index.html', persons=persons)

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