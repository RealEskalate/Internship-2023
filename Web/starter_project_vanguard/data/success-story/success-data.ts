class MockData {
  public name: string
  public image: string
  public category: string
  public location: string
  public heading1: string
  public paragraph1: string
  public heading2: string
  public paragraph2: string
  public heading3: string
  public paragraph3: string

  constructor(
    name: string,
    image: string,
    category: string,
    location: string,
    heading1: string,
    paragraph1: string,
    heading2: string,
    paragraph2: string,
    heading3: string,
    paragraph3: string
  ) {
    this.name = name
    this.image = image
    this.category = category
    this.location = location
    this.heading1 = heading1
    this.paragraph1 = paragraph1
    this.heading2 = heading2
    this.paragraph2 = paragraph2
    this.heading3 = heading3
    this.paragraph3 = paragraph3
  }
}

export const mockData: MockData[] = [
  new MockData(
    'Yisehak Bogale',
    '/images/success-story/isaac.png',
    'Software Engineering Intern',
    'Google - Mountain View, CA, USA',
    'My A2SV Experience',
    'I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.',
    'What I did/I am doing now',
    'Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!',
    'How the A2SV program changed my life',
    "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities."
  ),
  new MockData(
    'Lydia Gashawtena',
    '/images/success-story/lyda.png',
    'Software Engineering Intern',
    'Google - Mountain View, CA, USA',
    'My A2SV Experience',
    'I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.',
    'What I did/I am doing now',
    'Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!',
    'How the A2SV program changed my life',
    "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities."
  ),
  new MockData(
    'Biruk Ayalew',
    '/images/success-story/biruk.png',
    'Software Engineering Intern',
    'Google - Mountain View, CA, USA',
    'My A2SV Experience',
    'I heard about Africa to Silicon Valley from my friends and I was excited to join. Before joining A2SV I dreamt about solving real-world problems and attaining something that I could focus on and make myself better from it. At that time, it is safe to say, I knew very little about data structure and algorithms. It was because of the A2SV program that I got comfortable with algorithms. From the program, students also learn about improving communication skills and being confident besides acquiring problem-solving skills.',
    'What I did/I am doing now',
    'Google is a great place to work. You will work with the brightest minds in the world and find yourself moving forward. Their culture is great and inclusive, especially their free food!',
    'How the A2SV program changed my life',
    "I believe I would have not made it to Google if not for A2SV. In fact, I would not have got this far if it wasn't for A2SV. I don't even think we would have such type of opportunities if it was not for this organization. Previously, I used to think working at FAANG was impossible for us but A2SV changed my mindset. Now, we know that it is possible to work anywhere as long as one works hard and utilizes opportunities."
  ),
]
