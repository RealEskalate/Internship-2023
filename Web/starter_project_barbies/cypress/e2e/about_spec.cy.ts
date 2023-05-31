describe('About Page', () => {
  beforeEach(() => {
    // Visit the About page before each test
    cy.visit('/about')
  })

  it('should display the Hero section', () => {
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

  it('should display the Problems section', () => {
    // Check if the Problems section is visible
    cy.get('[test-id="problems-section"]').should('be.visible')
    // Check the "The Problem We Are Solving" section
    cy.contains('The Problem We Are Solving').should('exist')
    cy.get('[test-id="problems"]').children('div').should('have.length', 2) // Assuming there are two problem items in the fixture

    // Check the "How We Are Solving it" section
    cy.contains('How We Are Solving it').should('exist')
    cy.get('[test-id="solutions"]').children('div').should('have.length', 1) // Assuming there are one solution items in the fixture
  })

  it('should display the Projects Section', () => {
    // Check if the Projects list is visible
    cy.get('[test-id="projects-section"]').should('be.visible')
    // Find the ProjectCard components within the ProjectsList component
    cy.get('[test-id="projects"]')
      .find('[test-id="project-card"]')
      .should('have.length', 2) // Assuming there are two projects in the fixture
  })

  it('should display the Sessions Section', () => {
    // Check if the Sessions list is visible
    cy.get('[test-id="sessions-section"]').should('be.visible')
    // Find the ProjectCard components within the ProjectsList component
    cy.get('[test-id="sessions-section"]')
      .find('[test-id="session-card"]')
      .should('have.length', 6) // Assuming there are six projects in the fixture
  })
})
