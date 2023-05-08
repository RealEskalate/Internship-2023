import hakimHub from '../../public/img/about/projects/hakimhub.svg'
import trackSys from '../../public/img/about/projects/tracksys.svg'

export const socialProjects = [
  {
    image: hakimHub,
    title: 'Hakim Hub',
    content:
      'HakimHub is a platform that provides information about healthcare\
            facilities and healthcare professionals in Ethiopia. Hakimhub makes\
            information about hospitals, medical laboratories, and doctors\
            conveniently accessible to its users.',
    leftAligned: false,
    isImageLeft: true,
  },
  {
    image: trackSys,
    title: 'Track Sym',
    content:
      'TrackSym is a non-commercial app that uses crowd-sourcing to collect\
              and visualize the density of the relevant Covid-19 symptoms. Symptom\
              data, aggregated by places, can help people avoid visiting areas\
              that are heavily populated by symptomatic people.',
    leftAligned: true,
    isImageLeft: false,
  },
]
