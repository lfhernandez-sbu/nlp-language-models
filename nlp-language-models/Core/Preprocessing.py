import re


def dumb_sentence_segmenter(file):
    corpus = open(file, 'r')
    lines = corpus.read().split('.')
    return lines


def smart_sentence_segmenter(file):
    corpus = open(file, 'r')
    segmentedList = []
    for line in corpus:
        segmentedList.append(re.split(r'[.,;:_!*()\[\]?\"\-\n]', line))
    return segmentedList


def dumb_tokenizer(sentence):
    # TODO account for empty arrays
    tokens = []
    for i in range(len(sentence) - 1):
        tokens = sentence[i].split()
    return tokens


def main():
    file = "test.txt"
    corpus = smart_sentence_segmenter(file)
    # for line in corp:
    #     print(line)
    # corpus = (dumb_sentence_segmenter(file))
    tokens = []
    for line in corpus:
        tokens.append(dumb_tokenizer(line))

    for token in tokens:
        print(token)


main()
