import { mount } from '@cypress/react'
import Doctor from '../../components/Doctor'

describe('Doctor Component', () => {
  
    it('renders the doctor information correctly', () => {
        mount(<Doctor />)
      cy.get('.doctor-component').should('exist')
  
      cy.get('.doctor-photo')
        .should('have.attr', 'src', 'doctor-photo-url') // Replace 'doctor-photo-url' with the actual photo URL
  
      cy.contains('.doctor-fullName', 'Doctor Full Name') // Replace 'Doctor Full Name' with the actual full name
  
      cy.get('.doctor-profession')
        .should('have.class', 'bg-blue-500')
        .and('have.text', 'Profession')
  
      cy.contains('.doctor-hospital', 'Washington Medical Center | MCM Korean Hospital')
    })
  })
  