// https://kiparo.com/kotlin-arrays - а иначе как в джаве массив и не создашь
class Set<T>(var elements: List<T>) {

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
        elements = elements.filterNot { currentElem -> currentElem == elem }
        true
    } else {
        false
    }

    fun removeAll(elems: Collection<T>): Boolean = elems.maxOf { elem -> remove(elem) }

    fun retainAll(elems: Collection<T>): List<T> =
        elements.filter { currentElem -> elems.contains(currentElem) }

    fun clear() = removeAll(elements)

    fun clone(): Set<T> = Set(elements = this.elements)
}