// src/app/slices/product.js
import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import Swal from "sweetalert2";

const initialState = {
    products: [],
    carts: [],
    favorites: [],
    single: null,
    status: 'idle',
    error: null,
};

// Create an asynchronous thunk for fetching products
export const fetchProducts = createAsyncThunk(
    'products/fetchProducts',
    async () => {
        const response = await fetch('http://localhost:5080/api/products');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    }
);

const productsSlice = createSlice({
    name: 'products',
    initialState,
    reducers: {
        AddToCart: (state, action) => {
            let { id } = action.payload;
            let sepeteEklenecekUrun = state.carts.find(item => item.id === parseInt(id));
            if (sepeteEklenecekUrun === undefined) {
                let item = state.products.find(item => item.id === parseInt(id));
                item.quantity = 1;
                state.carts.push(item);
                Swal.fire({
                    title: 'Başarılı',
                    text: "Ürün sepete eklendi!",
                    icon: 'success',
                    showConfirmButton: false,
                    timer: 2000
                });
            }
        },
        getProductById: (state, action) => {
            let { id } = action.payload;
            let urunDetay = state.products.find(item => item.id === parseInt(id));
            state.single = urunDetay;
        },
        updateCart: (state, action) => {
            let { val, id } = action.payload;
            state.carts.forEach(item => {
                if (item.id === parseInt(id)) {
                    item.quantity = val;
                }
            });
        },
        removeCart: (state, action) => {
            let { id } = action.payload;
            let sepetinOnSonHali = state.carts.filter(item => item.id !== parseInt(id));
            state.carts = sepetinOnSonHali;
        },
        clearCart: (state) => {
            state.carts = [];
        },
        addToFavorites: (state, action) => {
            let { id } = action.payload;
            let item = state.favorites.find(item => item.id === parseInt(id));
            if (item === undefined) {
                let urunFavori = state.products.find(item => item.id === parseInt(id));
                urunFavori.quantity = 1;
                state.favorites.push(urunFavori);
                Swal.fire({
                    title: 'Başarılı',
                    text: 'İlgili ürün favorilere eklenmiştir',
                    icon: 'success'
                });
            } else {
                Swal.fire('Başarsız', 'İlgili ürün favorilere eklenemedi', 'warning');
            }
        },
        removeToFav: (state, action) => {
            let { id } = action.payload;
            let favorilerinOnSonHali = state.favorites.filter(item => item.id !== parseInt(id));
            state.favorites = favorilerinOnSonHali;
        },
        clearFav: (state) => {
            state.favorites = [];
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchProducts.pending, (state) => {
                state.status = 'loading';
            })
            .addCase(fetchProducts.fulfilled, (state, action) => {
                state.status = 'succeeded';
                state.products = action.payload;
            })
            .addCase(fetchProducts.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error.message;
            });
    }
});

export const { AddToCart, getProductById, updateCart, removeCart, clearCart, addToFavorites, removeToFav, clearFav } = productsSlice.actions;

export default productsSlice.reducer;