// https://kiparo.com/kotlin-arrays - а иначе как в джаве массив и не создашь
class Set_temp<T>(var elements: Array<T>) {

    fun size(): Int = elements.size

    fun isEmpty(): Boolean = elements.isEmpty()

    fun contains(elem: T): Boolean = elements.contains(elem)

    fun add(elem: T): Boolean = if (contains(elem)) {
        false
    } else {
        elements = elements.plus(elem)
        true
    }

    fun addAll(elems: Collection<T>): Boolean = elems.maxOf { elem -> add(elem) }

    fun remove(elem: T): Boolean = if (contains(elem)) {
        // bas cast and i will use List<T> instead Array<T>
        elements = elements.filterNot { currentElem -> currentElem == elem } as Array<T>
        true
    } else {
        false
    }

    fun removeAll(elems: Collection<T>): Boolean = elems.maxOf { elem -> remove(elem) }

    fun retainAll(elems: Collection<T>): Array<T> =
        // bas cast and i will use List<T> instead Array<T>
        elements.filter { currentElem -> elems.contains(currentElem) } as Array<T>

    fun clear() = elements.drop(elements.size)

    fun clone(): Set_temp<T> = this.clone()
}