// Import Redux dependencies
import { configureStore } from '@reduxjs/toolkit'
import { Provider } from 'react-redux'

// Import the component to be tested
import SessionsList from './SessionsList'

import { aboutApi } from '@/store/about/about-api'

const store = configureStore({
  reducer: { [aboutApi.reducerPath]: aboutApi.reducer },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(aboutApi.middleware),
})

describe('ProjectsList Component', () => {
  beforeEach(() => {
    // This is the solution to clear RTK Query cache before each test
    store.dispatch(aboutApi.util.resetApiState())

    // Set the API context for Cypress intercepts
    cy.intercept('http://localhost:5000/sessions', {
      fixture: 'about/sessions.json',
    }).as('getSessions')

    // Mount the component
    cy.mount(
      <Provider store={store}>
        <SessionsList />
      </Provider>
    )
  })
  it('should render the correct number of ProjectCard components', () => {
    // Wait for the sessions to load
    cy.wait('@getSessions')
    // Find the ProjectCard components within the ProjectsList component
    cy.get('[test-id="sessions-section"]')
      .find('[test-id="session-card"]')
      .should('have.length', 6) // Assuming there are six projects in the fixture
  })
})
