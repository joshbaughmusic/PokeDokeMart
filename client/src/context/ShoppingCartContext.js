import { createContext, useContext, useState } from 'react';

const ShoppingCartContext = createContext({});

export const useShoppingCart = () => {
  return useContext(ShoppingCartContext);
};

export const ShoppingCartProvider = ({ children }) => {
  const [cartItems, setCartItems] = useState([]);

  const getItemQuantity = (id) => {
    return cartItems.find((item) => item.id == id)?.quantity || 0;
  };

  const increaseCartQuantity = (id) => {
    setCartItems((currItems) => {
      return currItems.map((item) => {
        if (item.id === id) {
          return { ...item, quantity: item.quantity + 1 };
        } else {
          return item;
        }
      });
    });
  };

  const decreaseCartQuantity = (id) => {
    setCartItems((currItems) => {
      return currItems.map((item) => {
        if (item.id === id && item.quantity > 0) {
          return { ...item, quantity: item.quantity - 1 };
        } else {
          return item;
        }
      });
    });
  };

  const addToCart = (itemObj) => {
    const itemIndex = cartItems.findIndex((item) => item.id === itemObj.id);

    if (itemIndex === -1) {
      // Item does not exist in the cart, add it
      setCartItems([...cartItems, itemObj]);
    } else {
      // Item exists in the cart, update its quantity
      setCartItems((currItems) => {
        const updatedItems = [...currItems];
        updatedItems[itemIndex].quantity += itemObj.quantity;
        return updatedItems;
      });
    }
  };

  const removeFromCart = (id) => {
    setCartItems((currItems) => {
      return currItems.filter((item) => item.id !== id);
    });
  };

  return (
    <ShoppingCartContext.Provider
      value={{
        getItemQuantity,
        increaseCartQuantity,
        decreaseCartQuantity,
        addToCart,
        removeFromCart,
      }}
    >
      {children}
    </ShoppingCartContext.Provider>
  );
};
