def dumb_sentence_segmenter(file):
    corpus = open(file, "r")
    lines = corpus.read().split('.')
    for line in lines:
        print(line)
    print(len(lines))
    corpus.close()


def dumb_tokenizer(sentence):
    tokens = sentence.split(' ')
    print(tokens)


def main():
    file = "test.txt"
    dumb_sentence_segmenter(file)
    sentence = "The bumble-bee has a much longer tongue so it can get nectar"
    dumb_tokenizer(sentence)

main()
