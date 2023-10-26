import { createContext, useContext, useEffect, useState } from 'react';

const ShoppingCartContext = createContext({});

export const useShoppingCart = () => {
  return useContext(ShoppingCartContext);
};

const cartFromLocalStorage = JSON.parse(localStorage.getItem('cart') || '[]')


export const ShoppingCartProvider = ({ children }) => {
  const [cartItems, setCartItems] = useState(cartFromLocalStorage);

  useEffect(() => {
   localStorage.setItem('cart', JSON.stringify(cartItems))
  }, [cartItems])

  const getItemQuantity = (id) => {
    return cartItems.find((item) => item.id == id)?.quantity || 0;
  };

  const getUniqueItemCount = () => {
    return cartItems.length;
  };

  const alterCartQuantity = (itemObj, value) => {
    setCartItems((currItems) => {
      return currItems.map((i) => {
        if (i.id === itemObj.id && i.quantity > 0) {
          return { ...i, quantity: value };
        } else {
          return i;
        }
      });
    });
  }

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

  const clearCart = () => {
    setCartItems([])
  }

  return (
    <ShoppingCartContext.Provider
      value={{
        getItemQuantity,
        addToCart,
        removeFromCart,
        getUniqueItemCount,
        alterCartQuantity,
        clearCart,
        cartItems,
      }}
    >
      {children}
    </ShoppingCartContext.Provider>
  );
};
