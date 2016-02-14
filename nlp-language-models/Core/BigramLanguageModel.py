def compute_bigram_probability():
    text = "This ratio is called This ratio is called the relative frequency the use of relative frequency as a way to esitmate This ratio"
    augmented_text = add_edge_markers(text)
    corpus = augmented_text.lower().split()
    bigram_set = generate_bigram_list(corpus)
    for bigram in bigram_set:
        print(bigram + " = " + str(count_bigram_occurence(bigram, bigram_set)))


def add_edge_markers(corpus):
    return "<s> " + corpus + " </s>"


def generate_bigram_list(corpus):
    bigrams = []
    for word in range(len(corpus) - 1):
        current = corpus[word] + " " + corpus[word + 1]
        # if current not in bigrams:
        bigrams.append(current)
    return bigrams


def count_bigram_occurence(bigram, set):
    count = 0
    for current_bigram in set:
        if current_bigram == bigram:
            count += 1
    # Subtract edge-markers from total count of words in corpus
    return round(count / (len(set) - 2), 2)

def count_unigram_occurences(word, corpus):
    count = 0
    for current_word in corpus:
        if current_word == word:
            count += 1
    return count

compute_bigram_probability()
