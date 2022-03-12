class LimitedStack<T> {
    // максимальный размер стека
    private int maxSize;
    // элементы стека
    private T[] stackArray;
    // индекс вершины стека
    private int topIndex;

    // Конструктор
    public LimitedStack(int maxSize) {
        this.maxSize = maxSize;
        this.stackArray = (T[]) new Object[maxSize];
        this.topIndex = -1;
    }

    // Проверка на пустоту
    public boolean empty() {
        return topIndex == -1;
    }

    // Проверка на заполненность
    public boolean full() {
        return topIndex == maxSize - 1;
    }

    // Добавление нового элемента
    public void push(T newElement) throws Exception {
        if (full()) {
            throw new Exception("stack is full");
        }

        // Инкрементируем сначала topIndex и добавляем новый элемент
        stackArray[++topIndex] = newElement;
    }

    // Взятие элемента с вершины стека и последующим его удалением
    public T pop() throws Exception {
        if (empty()) {
            throw new Exception("stack is empty");
        }
        // После извлечения topIndex уменьшится на 1
        return stackArray[topIndex--];
    }

    // Просмотр элемента на вершине стека
    public T peek() throws Exception {
        if (empty()) {
            throw new Exception("stack is empty");
        }

        return stackArray[topIndex];
    }
}