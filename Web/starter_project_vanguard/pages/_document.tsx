import { Html, Head, Main, NextScript } from 'next/document'

export default function Document() {
  return (
    <Html lang="en">
       <Head>
          <link
            href="https://fonts.googleapis.com/css2?family=Neucha&display=swap"
            rel="stylesheet"
          />
          <link
          href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&family=Roboto&display=swap"
          rel="stylesheet"
        />
        </Head>
      <body>
        <Main />
        <NextScript />
      </body>
    </Html>
  )
}
