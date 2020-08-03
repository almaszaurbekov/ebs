"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import Flask, jsonify, render_template
from BookcityIntegration.functions import *
from BookcityIntegration import app

@app.route('/ebs/bookcity/<string:book>', methods=['GET'])
def bookcity_search(book):
    return jsonify(bookcity_parse(book))

@app.route('/ebs/bookcity/details/<string:url>', methods=['GET'])
def bookcity_search_details(url):
    return jsonify(bookcity_parse_details(url))