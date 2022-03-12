import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class StackTest {

    private Stack<Long> stack;

    @BeforeEach
    void setUp() {
        this.stack = new Stack<>();
    }

    @Test
    @DisplayName("Check method empty")
    void empty() {
        assertTrue(stack.empty(), "stack must be empty");

        stack.push(1L);

        assertFalse(stack.empty(), "stack must be not empty");
    }

    @Test
    @DisplayName("Check method push")
    void push() throws Exception {
        int stackSize = 100;
        for (int index = 0; index < stackSize; index++) {
            long finalLongIndex = index;
            assertDoesNotThrow(() -> stack.push(finalLongIndex));
            assertEquals(finalLongIndex, stack.peek(), String.format("top item is %d", finalLongIndex));
        }

        assertDoesNotThrow(() -> stack.push((long) (stackSize + 1)), "stack can hold more element");
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