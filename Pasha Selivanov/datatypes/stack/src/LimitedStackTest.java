import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class LimitedStackTest {

    private final int defaultMaxSize = 5;
    private LimitedStack<Long> stack;

    @BeforeEach
    void setUp() {
        this.stack = new LimitedStack<>(defaultMaxSize);
    }

    @Test
    @DisplayName("Check method empty")
    void empty() throws Exception {
        assertTrue(stack.empty(), "stack must be empty");

        stack.push(1L);

        assertFalse(stack.empty(), "stack must be not empty");
    }

    @Test
    @DisplayName("Check method full")
    void full() throws Exception {
        assertFalse(stack.full(), "stack must be not full");

        for (int index = 0; index < defaultMaxSize; index++) {
            stack.push((long) index);
        }

        assertTrue(stack.full(), "stack must be full");
    }

    @Test
    @DisplayName("Check method push")
    void push() throws Exception {
        for (int index = 0; index < defaultMaxSize; index++) {
            long finalLongIndex = index;
            assertDoesNotThrow(() -> stack.push(finalLongIndex));
            assertEquals(finalLongIndex, stack.peek(), String.format("top item is %d", finalLongIndex));
        }

        assertThrowsExactly(Exception.class, () -> stack.push((long) (defaultMaxSize + 1)), "stack is full");
    }

    @Test
    @DisplayName("Check method pop")
    void pop() throws Exception {
        assertThrowsExactly(Exception.class, () -> stack.pop(), "stack is empty");

        stack.push(10L);
        stack.push(11L);
        stack.push(12L);

        assertEquals(12L, stack.pop(), "top item is 12");
        assertEquals(11L, stack.pop(), "top item is 11");
        assertEquals(10L, stack.pop(), "top item is 10");

        assertThrowsExactly(Exception.class, () -> stack.pop(), "stack is empty");
    }

    @Test
    @DisplayName("Check method peek")
    void peek() throws Exception {
        assertThrowsExactly(Exception.class, () -> stack.peek(), "stack is empty");

        stack.push(10L);
        stack.push(11L);
        stack.push(12L);

        assertEquals(12L, stack.peek(), "top item is 12");
        assertNotEquals(11L, stack.peek(), "top item is still 12");
        assertNotEquals(10L, stack.peek(), "top item is still 12");
    }
}