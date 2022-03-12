import org.junit.jupiter.api.BeforeEach
import org.junit.jupiter.api.Test
import kotlin.test.assertEquals
import kotlin.test.assertNotEquals

internal class SetTest {

    // Создаем пустое множество
    var set = Set(elements = listOf<Long>())

    @BeforeEach
    fun setUp() {
        set = Set(elements = listOf())
    }

    @Test
    fun size() {
        assertEquals(0, set.size(), "size must be 0")
        set.add(1)
        assertEquals(1, set.size(), "size must be 1")
        set.add(2)
        assertEquals(2, set.size(), "size must be 2")
        assertNotEquals(3, set.size(), "size must be not 3")
    }

    @Test
    fun isEmpty() {
        assertEquals(true, set.isEmpty(), "set must be empty")
        set.add(1)
        assertEquals(false, set.isEmpty(), "set must be filled")
        set.add(2)
        assertEquals(false, set.isEmpty(), "set must be filled")
        assertNotEquals(true, set.isEmpty(), "set must be filled")
    }

    @Test
    fun contains() {
        assertEquals(false, set.contains(1), "set must be empty")
        set.add(10)
        assertEquals(true, set.contains(10), "set contains 10")
    }

    @Test
    fun add() {
        assertEquals(false, set.contains(1), "set must be empty")
        assertEquals(true, set.add(1), "set haven't elem 1")
        assertEquals(true, set.contains(1))
        assertEquals(false, set.add(1), "set already have elem 1")
        assertEquals(1, set.size(), "size must be 1")
    }

    @Test
    fun addAll() {
        assertEquals(false, set.contains(1), "set must be empty")
        assertEquals(false, set.contains(2), "set must be empty")
        assertEquals(false, set.contains(3), "set must be empty")
        assertEquals(true, set.addAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(true, set.contains(1))
        assertEquals(true, set.contains(2))
        assertEquals(true, set.contains(3))
        assertEquals(false, set.addAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(3, set.size(), "size must be 3")
    }

    @Test
    fun remove() {
        assertEquals(false, set.contains(1), "set must be empty")
        assertEquals(false, set.remove(1), "set haven't elem 1")
        assertEquals(0, set.size(), "size must be 0")
        assertEquals(true, set.add(1), "set haven't elem 1")
        assertEquals(true, set.remove(1), "set have elem 1")
        assertEquals(0, set.size(), "size must be 0")
    }

    @Test
    fun removeAll() {
        assertEquals(false, set.contains(1), "set must be empty")
        assertEquals(false, set.contains(2), "set must be empty")
        assertEquals(false, set.contains(3), "set must be empty")
        assertEquals(false, set.removeAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(true, set.addAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(true, set.contains(1))
        assertEquals(true, set.contains(2))
        assertEquals(true, set.contains(3))
        assertEquals(false, set.addAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(3, set.size(), "size must be 3")
        assertEquals(true, set.removeAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(0, set.size(), "size must be 0")
    }

    @Test
    fun retainAll() {
        set.addAll(longArrayOf(1, 2, 3).toList())
        val tempSet = longArrayOf(2, 3, 4).toList()

        val resultOfRetain = set.retainAll(tempSet)
        assertEquals(true, resultOfRetain.contains(2))
        assertEquals(true, resultOfRetain.contains(3))
        assertEquals(2, resultOfRetain.size, "size must be 2")
    }

    @Test
    fun clear() {
        assertEquals(0, set.size(), "size must be 0")
        assertEquals(true, set.addAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(3, set.size(), "size must be 3")
        set.clear()
        assertEquals(0, set.size(), "size must be 0")
    }

    @Test
    fun testClone() {
        assertEquals(true, set.addAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(3, set.size(), "size must be 3")
        var other = set.clone()
        assertEquals(3, other.size(), "size must be 3")
        assertEquals(true, set.addAll(longArrayOf(4, 5, 6).toList()))
        assertEquals(3, other.size(), "size must be 3")
        assertEquals(true, other.removeAll(longArrayOf(1, 2, 3).toList()))
        assertEquals(0, other.size(), "size must be 0")
    }
}