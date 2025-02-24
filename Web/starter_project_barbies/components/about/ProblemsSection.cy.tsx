// Import Redux dependencies
import { configureStore } from '@reduxjs/toolkit'
import { Provider } from 'react-redux'

// Import the component to be tested
import ProblemsSection from './ProblemsSection'
import { aboutApi } from '@/store/about/about-api'

const store = configureStore({
  reducer: { [aboutApi.reducerPath]: aboutApi.reducer },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(aboutApi.middleware),
})

describe('ProblemsSection Component', () => {
  beforeEach(() => {
    // This is the solution to clear RTK Query cache before each test
    store.dispatch(aboutApi.util.resetApiState())

    // Set the API context for Cypress intercepts
    cy.intercept('http://localhost:5000/problem-items', {
      fixture: 'about/problemItems.json',
    }).as('getProblemItems')
    cy.intercept('http://localhost:5000/solution-items', {
      fixture: 'about/solutionItems.json',
    }).as('getSolutionItems')

    // Mount the component
    cy.mount(
      <Provider store={store}>
        <ProblemsSection />
      </Provider>
    )
  })

  it('should display the component correctly', () => {
    // Wait for API requests to complete
    cy.wait(['@getProblemItems', '@getSolutionItems'])
    // Check the "The Problem We Are Solving" section
    cy.contains('The Problem We Are Solving').should('exist')
    cy.get('[test-id="problems"]').children('div').should('have.length', 2) // Assuming there are two problem items in the fixture

    // Check the "How We Are Solving it" section
    cy.contains('How We Are Solving it').should('exist')
    cy.get('[test-id="solutions"]').children('div').should('have.length', 1) // Assuming there are one solution items in the fixture
  })
})
