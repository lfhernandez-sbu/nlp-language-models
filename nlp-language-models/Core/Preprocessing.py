import re


def dumb_sentence_segmenter(file):
    corpus = open(file, 'r')
    lines = corpus.readlines()
    segmentedList = []
    for line in lines:
        segmentedList.append(re.split(r'[.,;:_!*()\[\]?\"\-\n]', line))
    return segmentedList


def dumb_tokenizer(sentence):
    tokens = []
    for i in sentence:
        if i is not None:
            tokens.append(i.split())
    return tokens


def main():
    file = "test.txt"
    corpus = (dumb_sentence_segmenter(file))
    tokens = []
    for line in corpus:
        tokens.append(dumb_tokenizer(line))
    for token in tokens:
        print(token)

main()
