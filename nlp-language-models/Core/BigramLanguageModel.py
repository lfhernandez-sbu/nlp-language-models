import math
import re

text = "A fat dog is a fat dog only when other fat dogs say he is a fat dog"


def compute_bigram_probability():
    # running total of estimation method probabilities
    mlep = 0.0
    lsp = 0.0
    adp = 0.0

    augmented_text = add_edge_markers(text)
    corpus = augmented_text.lower().split()
    bigram_set = generate_bigram_list(corpus)

    for bigram in bigram_set:
        bigram = bigram.split()
        mle = maximum_likelihood_estimate(bigram[0], bigram[1], bigram_set, corpus)
        ls = laplace_smoothing(bigram[0], bigram[1], bigram_set, corpus)
        ads = absolute_discounting(bigram[0], bigram[1], bigram_set, corpus)
        print("P(" + bigram[0] + " | " + bigram[1] + ")" + " = " + str(mle))
        mlep += math.log(mle, 2)
        lsp += math.log(ls, 2)
        adp += math.log(ads, 2)
    print("mle = " + str(2 ** mlep) + "\nls = " + str(2 ** lsp) + "\nabsolute discounting = " + str(2**adp))


def add_edge_markers(corpus):
    return "<s> " + corpus + " </s>"


def generate_bigram_list(corpus):
    bigrams = []
    for word in range(len(corpus) - 1):
        current = corpus[word] + " " + corpus[word + 1]
        bigrams.append(current)
    return bigrams


def count_ngram_occurence(ngram, set):
    count = 0
    for currentngram in set:
        if currentngram == ngram:
            count += 1
    return count


def generate_bigram(x):
    x = x.split()
    x = x[0] + " " + x[1]


def maximum_likelihood_estimate(x, y, bigramset, corpus):
    bigram = x + ' ' + y
    return count_ngram_occurence(bigram, bigramset) / count_ngram_occurence(x, corpus)


def laplace_smoothing(x, y, bigramset, corpus):
    bigram = x + ' ' + y
    return (count_ngram_occurence(bigram, bigramset) + 1) / (
    count_ngram_occurence(x, corpus) + len(get_vocabulary(corpus)))


def absolute_discounting(x, y, bigram_set, corpus):
    bigram = x + ' ' + y
    return (count_ngram_occurence(bigram, bigram_set) - 0.5)/ count_ngram_occurence(x, corpus)


def get_vocabulary(corpus):
    distinct = []
    for word in corpus:
        if word not in distinct:
            distinct.append(word)
    return distinct


compute_bigram_probability()
