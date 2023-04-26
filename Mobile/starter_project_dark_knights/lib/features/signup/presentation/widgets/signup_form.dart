import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import 'navigation.dart';
import 'buttons.dart';

class SignUpForm extends StatefulWidget {
  const SignUpForm({super.key});

  @override
  _SignUpFormState createState() => _SignUpFormState();
}

class _SignUpFormState extends State<SignUpForm> {
  bool _showPassword = true; // To toggle password visibility

  @override
  Widget build(BuildContext context) {
    final double screenHeight = MediaQuery.of(context).size.height;
//MediaQuery to get the screen height and adjust the sizes of UI elements accordingly.
    return Column(
      children: [
        Column(
          children: [
            const Align(
              alignment: Alignment.centerLeft,
              child: Text(
                'Welcome',
                style: TextStyle(
                    fontWeight: FontWeight.w700,
                    fontSize: 24,
                    fontFamily: "Urbanist"),
              ),
            ),
            SizedBox(height: screenHeight * 0.02),
            const Align(
              alignment: Alignment.centerLeft,
              child: Text('Provide credentials to sign up',
                  style: TextStyle(
                      fontWeight: FontWeight.w800,
                      fontFamily: "Poppins",
                      color: secondaryTextColor)),
            ),
          ],
        ),
        SizedBox(height: screenHeight * 0.04),
        //Username text field
        const TextField(
          decoration: InputDecoration(
              labelText: 'Username',
              // suffixText: ,
              labelStyle: TextStyle(
                fontFamily: "Urbanist2",
                fontSize: 20,
                color: secondaryTextColor,
                fontStyle: FontStyle.italic,
              )),
        ),
        SizedBox(height: screenHeight * 0.07),
        //password text field
        TextField(
          decoration: InputDecoration(
            labelText: 'Password',
            labelStyle: TextStyle(
              // height: 50,
              fontSize: 20,
              fontStyle: FontStyle.italic,
              fontFamily: "Urbanist2",
              color: secondaryTextColor,
            ),
            // Adding a suffix text  to show/hide password
            suffixIcon: TextButton(
              child: Text(_showPassword ? 'show' : 'hide'),
              onPressed: () {
                setState(() {
                  _showPassword = !_showPassword;
                });
              },
            ),
          ),
          obscureText: _showPassword, // setting obscureText to hide password
        ),

        SizedBox(height: screenHeight * 0.15),
        const SizedBox(
          height: 60,
          width: double.infinity,
          child: button_widget(),
        ),
        SizedBox(height: screenHeight * 0.02),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Text(
              'Have an account?',
              style: TextStyle(
                  color: secondaryTextColor,
                  fontFamily: "Poppins",
                  fontWeight: FontWeight.w700),
            ),
            TextButton(
              onPressed: () {},
              child: const Text('Login'),
            ),
          ],
        ),
      ],
    );
  }
}
