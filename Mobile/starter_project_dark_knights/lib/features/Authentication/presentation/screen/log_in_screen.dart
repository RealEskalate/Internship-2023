import 'package:flutter/material.dart';

class Login extends StatelessWidget {
  const Login({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          Align(
            alignment: Alignment.topCenter,
            child: Image.asset(
              'images/a2sv.png',
              height: MediaQuery.of(context).size.height * 0.2,
              fit: BoxFit.fitWidth,
            ),
          ),
          Expanded(
            child: Stack(children: [
              Container(
                width: double.infinity,
                decoration: const BoxDecoration(
                    color: Color(0xff376AED),
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(25.0),
                      topRight: Radius.circular(25.0),
                    )),
                height: MediaQuery.of(context).size.height * 0.18,
                padding: EdgeInsets.symmetric(
                  horizontal: MediaQuery.of(context).size.height * 0.16,
                  vertical: MediaQuery.of(context).size.width * 0.04,
                ),
                child: Row(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    customText(text: "LOGIN", color: Colors.white),
                    SizedBox(width: MediaQuery.of(context).size.width * 0.3),
                    customText(
                      text: "SIGNUP",
                      color: Colors.white.withOpacity(0.4),
                    ),
                  ],
                ),
              ),
              Positioned(
                  top: MediaQuery.of(context).size.height * 0.087,
                  child: Container(
                    width: MediaQuery.of(context).size.width,
                    height: MediaQuery.of(context).size.height,
                    decoration: const BoxDecoration(
                        border: null,
                        color: Colors.white,
                        borderRadius: const BorderRadius.only(
                          topLeft: Radius.circular(25.0),
                          topRight: Radius.circular(25.0),
                        )),
                    padding: const EdgeInsets.symmetric(
                        horizontal: 28, vertical: 28),
                    child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text("Welcome back",
                              style: TextStyle(
                                fontFamily: "Urbanist",
                                color: Colors.black,
                                fontWeight: FontWeight.w600,
                                fontSize: 24,
                              )),
                          SizedBox(height: 12),
                          Text("Sign in with your account",
                              style: TextStyle(
                                color: Color(0xff2D4379),
                                fontWeight: FontWeight.w900,
                                fontSize: 14,
                              )),
                          SizedBox(height: 30),
                          Text(
                            "Username",
                            style: TextStyle(
                              fontFamily: "Urbanist",
                              fontStyle: FontStyle.italic,
                              color: Color(0xff2D4379),
                              fontSize: 14,
                            ),
                          ),
                          TextField(
                            decoration: InputDecoration(
                              hintText: 'Jonathandavis@gmail.com',
                              hintStyle: TextStyle(
                                color: Colors.black,
                                fontFamily: "Urbanist",
                                fontSize: 16,
                                fontWeight: FontWeight.w500,
                              ),
                            ),
                          ),
                          SizedBox(height: 20),
                          Text(
                            "Password",
                            style: TextStyle(
                                fontFamily: "Urbanist",
                                fontStyle: FontStyle.italic,
                                color: Color(0xff2D4379),
                                fontSize: 14),
                          ),
                          Row(
                            children: [
                              Expanded(
                                child: TextField(
                                  decoration: InputDecoration(
                                    hintText: '••••••',
                                    hintStyle: TextStyle(
                                      color: Colors.black,
                                      fontSize: 24,
                                      letterSpacing: 8,
                                      fontWeight: FontWeight.w500,
                                    ),
                                  ),
                                ),
                              ),
                              TextButton(
                                onPressed: () {},
                                child: Text(
                                  "Show",
                                  style: TextStyle(
                                    color: Colors.blue,
                                    fontWeight: FontWeight.w600,
                                  ),
                                ),
                              ),
                            ],
                          ),
                          SizedBox(height: 100),
                          Container(
                            width: MediaQuery.of(context).size.width * 0.9,
                            height: 50,
                            child: ElevatedButton(
                              onPressed: () {},
                              style: ElevatedButton.styleFrom(
                                primary: Color(0xff376AED),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(10),
                                ),
                              ),
                              child: Text(
                                "Login",
                                style: TextStyle(
                                  fontSize: 18,
                                ),
                              ),
                            ),
                          ),
                          SizedBox(height: 10),
                          Row(
                              mainAxisAlignment: MainAxisAlignment.center,
                              children: [
                                Text(
                                  "Forgot your password?",
                                  style: TextStyle(
                                      fontWeight: FontWeight.w900,
                                      fontSize: 14,
                                      color: Color(0xff2D4379)),
                                ),
                                SizedBox(width: 10),
                                Text(
                                  "Reset here",
                                  style: TextStyle(
                                      color: Color(0xff376AED),
                                      fontWeight: FontWeight.w500,
                                      fontSize: 14,
                                      fontFamily: "Urbanist"),
                                ),
                              ]),
                        ]),
                  ))
            ]),
          ),
        ],
      ),
    );
  }
}

class customText extends StatelessWidget {
  final String text;
  final Color color;
  const customText({
    super.key,
    required this.text,
    required this.color,
  });

  @override
  Widget build(BuildContext context) {
    return Text(
      text,
      style: TextStyle(
        color: color,
        fontWeight: FontWeight.w700,
        fontSize: 18,
        fontFamily: "Urbanist",
      ),
    );
  }
}
