import React from 'react'
import HeroSection from './HeroSection'

describe('<HeroSection />', () => {
  it('should display the component correctly', () => {
    // see: https://on.cypress.io/mounting-react
    cy.mount(<HeroSection />)
    // Check if the Hero section is visible
    cy.get('[test-id="hero-section"]').should('be.visible')
    // Check if the component contains specific elements
    cy.contains('Africa to Silicon Valley').should('exist')
    cy.contains('A2SV is a social enterprise').should('exist')
    cy.get('button').first().should('have.text', 'Meet Our Team')
    cy.contains('Group Activities').should('exist')
    cy.get('img[alt="education"]').should('exist')
    cy.contains('The Education Process').should('exist')
    cy.get('img[alt="development"]').should('exist')
    cy.contains('Development Phase').should('exist')
    cy.contains('20% percent growth').should('exist')
    cy.contains('180% students growth 20% faster learning track').should(
      'exist'
    )
  })
})
