import { renderHook } from '@testing-library/react-hooks';
import { Provider } from 'react-redux';
import configureStore from 'redux-mock-store';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { useGetDoctorsQuery, useGetDoctorByIdQuery, useSearchDoctorQuery } from './yourFile';

// Mock Redux store
const mockStore = configureStore([]);
const store = mockStore({});

describe('HakimList API', () => {
  beforeEach(() => {
    // Clear any actions from previous tests
    store.clearActions();
  });

  it('should fetch doctors list', async () => {
    const { result, waitFor } = renderHook(() => useGetDoctorsQuery(), {
      wrapper: ({ children }) => <Provider store={store}>{children}</Provider>,
    });

    await waitFor(() => result.current.isSuccess);

    expect(result.current.data).toEqual(/* Expected data */);
    expect(result.current.error).toBeUndefined();
  });

  it('should fetch doctor by ID', async () => {
    const id = '123';
    const { result, waitFor } = renderHook(() => useGetDoctorByIdQuery(id), {
      wrapper: ({ children }) => <Provider store={store}>{children}</Provider>,
    });

    await waitFor(() => result.current.isSuccess);

    expect(result.current.data).toEqual(/* Expected data */);
    expect(result.current.error).toBeUndefined();
  });

  it('should search for doctors', async () => {
    const name = 'John Doe';
    const { result, waitFor } = renderHook(() => useSearchDoctorQuery(name), {
      wrapper: ({ children }) => <Provider store={store}>{children}</Provider>,
    });

    await waitFor(() => result.current.isSuccess);

    expect(result.current.data).toEqual(/* Expected data */);
    expect(result.current.error).toBeUndefined();
  });
});
