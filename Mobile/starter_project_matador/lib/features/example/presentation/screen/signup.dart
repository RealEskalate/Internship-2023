// Import flutter heplper library
import 'package:flutter/material.dart';

class SignUp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        title: 'Sign Up Page',
        home: Scaffold(
            backgroundColor: Colors.white,
            body: SafeArea(
                child: ListView(children: <Widget>[
              SizedBox(
                height: 130,
                width: 234,
                child: Image(
                  height: 54,
                  width: 141,
                  image: NetworkImage(
                      "https://media.licdn.com/dms/image/D4E16AQGS-26jpTdk2w/profile-displaybackgroundimage-shrink_200_800/0/1671689947030?e=2147483647&v=beta&t=6y-EPCeib7vMuOKrklKkiVnqCw8KEH0q6VfJovmBb9A"),
                ),
              ),
              Container(
                height: 76,
                width: 295,
                decoration: BoxDecoration(
                  color: Color(0xff376AED),
                  borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(28),
                    topRight: Radius.circular(28),
                  ),
                  boxShadow: [
                    BoxShadow(
                      color: Color.fromRGBO(79, 91, 121, 0.1),
                      blurRadius: 22,
                      offset: Offset(0, 4),
                    ),
                  ],
                ),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: <Widget>[
                    Text(
                      'LOGIN',
                      style: TextStyle(
                        fontFamily: 'Urbanist',
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                        letterSpacing: 1,
                        color: Colors.white.withOpacity(0.25),
                      ),
                    ),
                    Text(
                      'SIGNUP',
                      style: TextStyle(
                        fontFamily: 'Urbanist',
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                        letterSpacing: 1,
                        color: Colors.white,
                      ),
                    ),
                  ],
                ),
              ),
              Expanded(
                  child: Container(
                width: double.infinity,
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(28),
                    topRight: Radius.circular(28),
                  ),
                  boxShadow: [
                    BoxShadow(
                      color: Color.fromRGBO(82, 130, 255, 0.09),
                      blurRadius: 32,
                      offset: Offset(0, -25),
                    ),
                  ],
                ),
                child: Padding(
                  padding: const EdgeInsets.symmetric(
                    horizontal: 24,
                    vertical: 32,
                  ),
                  child: Column(
                    children: <Widget>[
                      Text(
                        'WELCOME',
                        style: TextStyle(
                          fontFamily: 'Urbanist',
                          fontWeight: FontWeight.bold,
                          fontSize: 24,
                          color: Color(0xff0D253C),
                        ),
                      ),
                      SizedBox(height: 16),
                      Text(
                        'Provide credentials to signup',
                        style: TextStyle(
                          fontFamily: 'Poppins',
                          fontWeight: FontWeight.bold,
                          fontSize: 14,
                          color: Color(0xff2D4379),
                        ),
                      ),
                      SizedBox(height: 32),
                      Container(
                        margin: EdgeInsets.only(top: 8),
                        height: 1,
                        width: 295,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(12),
                          color: Color(0xFFD9DFEB),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 24),
                        child: TextField(
                          decoration: InputDecoration(
                            labelText: 'Username',
                            hintText: 'abebe@gmail.com',
                            hintStyle: TextStyle(
                              fontFamily: 'Urbanist',
                              fontStyle: FontStyle.italic,
                              fontWeight: FontWeight.w100,
                              fontSize: 14,
                              color: Color(0xFF2D4379),
                            ),
                          ),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 24),
                        child: TextField(
                          decoration: InputDecoration(
                            labelText: 'Password',
                            hintText: '●●●●●●●●',
                            hintStyle: TextStyle(
                              fontFamily: 'Urbanist',
                              fontStyle: FontStyle.italic,
                              fontWeight: FontWeight.w100,
                              fontSize: 14,
                              color: Color(0xFF2D4379),
                            ),
                          ),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 8),
                        height: 1,
                        width: 295,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(12),
                          color: Color(0xFFD9DFEB),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 24),
                        width: 295,
                        height: 56,
                        decoration: BoxDecoration(
                          color: Color(0xFF376AED),
                          borderRadius: BorderRadius.circular(20),
                        ),
                        child: Center(
                          child: Text(
                            'SIGNUP',
                            style: TextStyle(
                              fontFamily: 'Urbanist',
                              fontWeight: FontWeight.w700,
                              fontSize: 18,
                              color: Color(0xFFFFFFFF),
                              letterSpacing: 1.5,
                            ),
                          ),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 24),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Text(
                              'Have an account?  ',
                              style: TextStyle(
                                fontFamily: 'Urbanist',
                                fontWeight: FontWeight.w500,
                                fontSize: 14,
                                color: Color(0xFF2D4379),
                              ),
                            ),
                            GestureDetector(
                              onTap: () {},
                              child: Text(
                                'Login',
                                style: TextStyle(
                                  fontFamily: 'Urbanist',
                                  fontWeight: FontWeight.w700,
                                  fontSize: 14,
                                  color: Color(0xFF376AED),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ))
            ]))));
  }
}
