public class Stack<T> {
    // элементы стека
    private T[] stackArray;

    // Конструктор
    public Stack() {
        this.stackArray = (T[]) new Object[0];
    }

    // Проверка на пустоту
    public boolean empty() {
        return stackArray.length == 0;
    }

    // Добавление нового элемента
    public void push(T newElement) {
        // Создаем новый массив на 1 элемент больше
        int topIndex = this.stackArray.length;
        T[] newStackArray = (T[]) new Object[topIndex + 1];
        // Копируем значения из старого массива в новый
        System.arraycopy(this.stackArray, 0, newStackArray, 0, topIndex);

        // В новый массив добавляем новый элемент
        newStackArray[topIndex] = newElement;
        this.stackArray = newStackArray;
    }

    // Взятие элемента с вершины стека и последующим его удалением
    public T pop() throws Exception {
        if (empty()) {
            throw new Exception("stack is empty");
        }

        int topIndex = this.stackArray.length;
        T[] newStackArray = (T[]) new Object[topIndex - 1];
        // Копируем значения из старого массива в новый
        System.arraycopy(this.stackArray, 0, newStackArray, 0, newStackArray.length);

        T topElement = stackArray[topIndex - 1];
        this.stackArray = newStackArray;
        return topElement;
    }

    // Просмотр элемента на вершине стека
    public T peek() throws Exception {
        int topIndex = this.stackArray.length;

        if (empty()) {
            throw new Exception("stack is empty");
        }

        return stackArray[topIndex - 1];
    }
}
