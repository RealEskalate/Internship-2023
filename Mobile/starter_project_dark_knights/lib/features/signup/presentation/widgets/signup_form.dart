import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import 'buttons.dart';
import '../../../../core/utils/style.dart';

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
            Align(
              alignment: Alignment.centerLeft,
              child: Text(
                'Welcome',
                style: TextStyle(
                    fontWeight: FontWeight.w700,
                    fontSize: screenHeight * 0.03,
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
        TextField(
            style: style(screenHeight, 0),
            decoration: InputDecoration(
              labelText: 'Username',
              // suffixText: ,
              labelStyle: textStyle(screenHeight, 0.5),
            )),
        SizedBox(height: screenHeight * 0.05),

        //password text field
        TextField(
          style: style(screenHeight, 9),
          decoration: InputDecoration(
            labelText: 'Password',
            labelStyle: textStyle(screenHeight, 0.5),
            // Adding a suffix text  to show/hide password
            suffixIcon: InkWell(
              child: Text(
                _showPassword ? 'show' : 'hide',
                style: const TextStyle(color: secondaryColor),
              ),
              onTap: () {
                setState(() {
                  _showPassword = !_showPassword;
                });
              },
            ),
          ),
          obscureText: _showPassword, // setting obscureText to hide password
        ),

        SizedBox(height: screenHeight * 0.15),

        SizedBox(
          height: screenHeight * 0.07,
          width: double.infinity,
          child: const ButtonWidget(),
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
            SizedBox(
              width: screenHeight * 0.002,
            ),
            InkWell(
              onTap: () {},
              child: const Text(
                "Login",
                style: TextStyle(color: secondaryColor),
              ),
            ),
          ],
        ),
      ],
    );
  }
}
