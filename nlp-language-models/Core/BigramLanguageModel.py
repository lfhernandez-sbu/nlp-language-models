import math
import re

text = "This ratio is called This ratio is called the relative frequency the use of relative frequency as a way to esitmate This ratio"

def compute_bigram_probability():
    probability = 0.0
    lsp = 0.0
    augmented_text = add_edge_markers(text)
    corpus = augmented_text.lower().split()
    bigram_set = generate_bigram_list(corpus)
    for bigram in bigram_set:
        bigram = bigram.split()
        mle = maximum_likelihood_estimate(bigram[0], bigram[1], bigram_set, corpus)
        ls = laplace_smoothin(bigram[0], bigram[1], bigram_set, corpus)
        print("P(" + bigram[0] + " | " + bigram[1] + ")" + " = " +str(mle))
        probability += math.log(mle)
        lsp += math.log(ls)
    print("mle = " + str(2**probability) + "\nls=" + str(2**lsp))


def add_edge_markers(corpus):
    return "<s> " + corpus + " </s>"


def generate_bigram_list(corpus):
    bigrams = []
    for word in range(len(corpus) - 1):
        current = corpus[word] + " " + corpus[word + 1]
        if current not in bigrams:
            bigrams.append(current)
    return bigrams


def count_ngram_occurence(ngram, set):
    count = 0
    for current_ngram in set:
        if current_ngram == ngram:
            count += 1
    return count


def generate_bigram(x):
    x = x.split()
    x = x[0] + " " + x[1]


def maximum_likelihood_estimate(x, y, bigram_set, corpus):
    bigram = x + ' ' + y
    return count_ngram_occurence(bigram, bigram_set ) / count_ngram_occurence(x, corpus)



def laplace_smoothin(x,y, bigram_set, corpus):
    vocabulary = print(len(re.findall('\w+', corpus)))
    bigram = x + ' ' + y
    return (count_ngram_occurence(bigram, bigram_set ) + 1) / (count_ngram_occurence(x, corpus) + vocabulary)
compute_bigram_probability()
