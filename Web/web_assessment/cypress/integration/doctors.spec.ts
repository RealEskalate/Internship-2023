describe('Home Page', () => {
  beforeEach(() => {
    cy.visit('/') // Replace '/' with the appropriate URL of your application
  })

  it('displays input field and search button', () => {
    cy.get('input[type="text"]').should('exist')
    cy.get('button').contains('Search').should('exist')
  })

  it('fetches doctors on initial load', () => {
    cy.intercept('POST', '/api/doctors/fetch-with-pagination', { fixture: 'doctors.json' }).as('fetchDoctors')

    cy.wait('@fetchDoctors').then(({ response }) => {
      const data = response.body.data
      expect(data).to.be.an('array')
      // Assert the rendered doctors
      cy.get('[data-cy="doctor-component"]').should('have.length', data.length)
    })
  })

  it('navigates to individual doctor page when clicked', () => {
    cy.intercept('POST', '/api/doctors/fetch-with-pagination', { fixture: 'doctors.json' }).as('fetchDoctors')

    cy.wait('@fetchDoctors')

    cy.get('[data-cy="doctor-component"]').first().click()

    cy.url().should('include', '/doctor-id') // Replace 'doctor-id' with the actual doctor ID
  })

  it('fetches doctors based on search query', () => {
    const searchQuery = 'John Doe'
    cy.intercept('POST', '/api/doctors/search', { fixture: 'doctors.json' }).as('searchDoctors')

    cy.get('input[type="text"]').type(searchQuery)
    cy.get('button').contains('Search').click()

    cy.wait('@searchDoctors').then(({ request }) => {
      const requestBody = request.body
      expect(requestBody.query).to.equal(searchQuery)
      // Assert the rendered doctors based on the search results
      cy.get('[data-cy="doctor-component"]').should('have.length', 10) // Assuming 10 doctors are fetched
    })
  })

  it('navigates to previous and next pages when clicked', () => {
    cy.intercept('POST', '/api/doctors/fetch-with-pagination', { fixture: 'doctors.json' }).as('fetchDoctors')

    cy.wait('@fetchDoctors')

    cy.get('button').contains('previous').click()
    cy.wait('@fetchDoctors').then(({ request }) => {
      const previousPage = request.body.page - 1
      // Assert the rendered doctors based on the previous page
      cy.get('[data-cy="doctor-component"]').should('have.length', 10) // Assuming 10 doctors are fetched
      cy.contains('Page: ' + previousPage)
    })

    cy.get('button').contains('Next').click()
    cy.wait('@fetchDoctors').then(({ request }) => {
      const nextPage = request.body.page + 1
      // Assert the rendered doctors based on the next page
      cy.get('[data-cy="doctor-component"]').should('have.length', 10) // Assuming 10 doctors are fetched
      cy.contains('Page: ' + nextPage)
    })
  })
})
