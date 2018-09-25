import os
import googlesearch as gs
from urllib.request import urlopen, Request
from bs4 import BeautifulSoup
import nltk
import Summarizer

keywords = ['what', 'if', 'who', 'when', 'where', 'why']
sources = []


def get_full_pathname(name):
    filename = os.path.abspath(os.path.join('.', 'sources', name + '.source'))
    return filename


def get_question(question):
    counter = 0;
    for keyword in keywords:
        if keyword in question.lower():
            word_in_question = keywords[counter]

            return word_in_question
        counter += 1


def keyword_if_processing(question):
    pass


def answer_question_from_url(question, name_of_doc):
    counter = 1
    urls = []

    for url in gs.search(question):
        print("The {} URL is:".format(counter) + url)
        urls.append(url)
        counter += 1
        if counter > 10:
            break
    counter = 1
    for url in urls:
        url_to_use = url
        hdr = {'User-Agent': 'Mozilla/5.0'}
        req = Request(url_to_use, headers=hdr)
        html = urlopen(req)
        bsObj = BeautifulSoup(html.read(), 'lxml')
        summrarized_text = Summarizer.summarize(url)
        print(summrarized_text)
        f = open(name_of_doc, "w")
        f.write(str(summrarized_text))
        f.close()
        counter += 1


def answer_question_from_text(text):
    summrarized_text = Summarizer.summarize(text)
    print(summrarized_text)

def answer_question_discord(question, urlsToSearch):
    counter = 1
    urls = []

    for url in gs.search(question):
        urls.append(url)
        counter += 1
        if counter > urlsToSearch:
            break
    counter = 1
    for url in urls:
        url_to_use = url
        hdr = {'User-Agent': 'Mozilla/5.0'}
        req = Request(url_to_use, headers=hdr)
        html = urlopen(req)
        bsObj = BeautifulSoup(html.read(), 'lxml')
        summrarized_text = Summarizer.summarize(url)
        counter += 1
        return summrarized_text

answer_question_from_url("What is Python", "WhatIsPython.txt")
