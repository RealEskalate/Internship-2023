// Import Redux dependencies
import { configureStore } from '@reduxjs/toolkit'
import { Provider } from 'react-redux'

// Import the component to be tested
import ProjectsList from './ProjectsList'

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
    cy.intercept('http://localhost:5000/projects', {
      fixture: 'about/projects.json',
    }).as('getProjects')

    // Mount the component
    cy.mount(
      <Provider store={store}>
        <ProjectsList />
      </Provider>
    )
  })

  it('should render the correct number of ProjectCard components', () => {
    // Wait for the projects to load
    cy.wait('@getProjects')
    // Find the ProjectCard components within the ProjectsList component
    cy.get('[test-id="projects"]')
      .find('[test-id="project-card"]')
      .should('have.length', 2) // Assuming there are two projects in the fixture
  })
})
