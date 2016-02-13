def compute_bigram_probability():
    text = add_edge_markers(
        "This ratio is called This ratio is called the relative frequency the use of relative frequency as a way to esitmate This ratio")
    corpus = text.split()
    bigrams = to_bigram_list(corpus)
    for bigram in bigrams:
        print(bigram + " = " + str(count_bigram_occurence(bigram, bigrams)))


def add_edge_markers(corpus):
    return "<s> " + corpus + " </s>"


def to_bigram_list(corpus):
    bigrams = []
    for word in range(len(corpus) - 1):
        current = corpus[word] + " " + corpus[word + 1]
        if current not in bigrams:
            bigrams.append(current)
    return bigrams


def count_bigram_occurence(bigram, corpus):
    count = 0
    for currentBigram in corpus:
        if bigram is currentBigram:
            count += 1
    # Subtract edge-markers from total count of words in corpus
    return round(count / (len(corpus) - 2), 2)


compute_bigram_probability()
