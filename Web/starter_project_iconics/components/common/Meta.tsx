import Head from 'next/head'

interface Props {
  title?: string
  keywords?: string
  description?: string
}

const Meta: React.FC<Props> = ({ title, keywords, description }) => {
  return (
    <Head>
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <meta name="keywords" content={keywords} />
      <meta name="description" content={description} />
      <meta charSet="utf-8" />
      <link rel="icon" href="/favicon.ico" />
      <title>{title}</title>
    </Head>
  )
}

Meta.defaultProps = {
  title: 'A2SV',
  keywords: 'A2SV - Africa to Silicon Valley',
  description:
    'Creating opportunities for African Students: A2SV offers training program that initially focuses on problem-solving and personal development.',
}

export default Meta
