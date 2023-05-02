import 'package:flutter/material.dart';

class Login extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final timeDisplay = Text("9:41");

    final iconRow = Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Transform.scale(scale: 0.8, child: Icon(Icons.signal_cellular_4_bar)),
        SizedBox(width: 8),
        Transform.scale(scale: 0.8, child: Icon(Icons.wifi)),
        SizedBox(width: 8),
        Transform.scale(scale: 0.8, child: Icon(Icons.battery_full)),
      ],
    );

    return MaterialApp(
      home: Scaffold(
        body: Column(
          children: [
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  timeDisplay,
                  iconRow,
                ],
              ),
            ),
            Image.asset(
              'images/a2sv.jpg',
              //width: 200, // set the width of the image
              height: 150, // set the height of the image
            ),

            //Container(height: 150, child: Image.asset('a2sv.jpg')),
            Container(
              width: double.infinity,
              child: ClipRRect(
                borderRadius: const BorderRadius.only(
                  topLeft: Radius.circular(20.0),
                  topRight: Radius.circular(20.0),
                ),
                child: Container(
                  height: 50,
                  color: Colors.blue[900],
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        "LOGIN",
                        style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                        ),
                      ),
                      SizedBox(width: 80),
                      Text(
                        "SIGNUP",
                        style: TextStyle(
                          color: Colors.blueGrey[300],
                          fontWeight: FontWeight.w400,
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
            Padding(
              padding: EdgeInsets.only(top: 30.0, left: 40.0),
              child: Column(
                children: [
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      "Welcome back",
                      style: TextStyle(
                        color: Colors.black,
                        fontWeight: FontWeight.w400,
                        fontSize: 20,
                      ),
                    ),
                  ),
                  SizedBox(height: 10),
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      "Sign in with your account",
                      style: TextStyle(
                        color: Colors.grey[700],
                        fontWeight: FontWeight.w900,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  SizedBox(height: 20),
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      "Username",
                      style: TextStyle(
                        fontStyle: FontStyle.italic,
                        color: Colors.grey[400],
                        fontSize: 17,
                      ),
                    ),
                  ),
                  SizedBox(height: 10),
                  Align(
                      alignment: Alignment.centerLeft,
                      child: TextField(
                        decoration: InputDecoration(
                          hintText: 'Jonathandavis@gmail.com',
                          border: UnderlineInputBorder(
                            borderSide:
                                BorderSide(color: Colors.red, width: 2.0),
                            // Change the border style to dotted, dashed, or solid.
                            // You can also add other styles such as BorderStyle.solid and BorderStyle.dashed.
                            //borderSide: BorderStyle.solid,
                          ),
                        ),
                      )),
                  SizedBox(height: 10),
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      "Password",
                      style: TextStyle(
                        fontStyle: FontStyle.italic,
                        color: Colors.grey[400],
                        fontSize: 17,
                      ),
                    ),
                  ),
                  Align(
                      alignment: Alignment.centerLeft,
                      child: TextField(
                        obscureText: true,
                        decoration: InputDecoration(
                          hintText: '••••••',
                          hintStyle: TextStyle(
                            fontSize: 24, // Change the font size as desired
                            letterSpacing:
                                8, // Increase the space between the dots
                            fontWeight: FontWeight.bold,
                          ),
                          border: UnderlineInputBorder(
                            borderSide:
                                BorderSide(color: Colors.red, width: 2.0),
                            // Change the border style to dotted, dashed, or solid.
                            // You can also add other styles such as BorderStyle.solid and BorderStyle.dashed.
                            //borderStyle: BorderStyle.solid,
                          ),
                        ),
                      )),
                  SizedBox(height: 20),
                  Container(
                    width: 400,
                    height: 50,
                    child: ElevatedButton(
                      onPressed: () {},
                      style: ElevatedButton.styleFrom(
                        primary: Colors.blue[900],
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

                  //SizedBox(height: 10),
                  Align(
                    alignment: Alignment.centerRight,
                    child: Row(
                      children: [
                        Text(
                          "Forgot your password?",
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        Text(
                          "Reset here",
                          style: TextStyle(
                            color: Colors.blue[900],
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            )
          ],
        ),
      ),
      debugShowCheckedModeBanner: false,
    );
  }
}
