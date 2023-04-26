import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import '../screen/pages/signup.dart';

class TopNavigate extends StatelessWidget {
  const TopNavigate({
    super.key,
  });
  @override
  Widget build(BuildContext context) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        TextButton(
          onPressed: () {
            // Functionality to navigate to login page
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => (const SignUpPage())),
            );
          },
          child: const Text(
            'LOGIN',
            style: TextStyle(
                color: Color.fromARGB(167, 255, 255, 255),
                fontFamily: "Urbanist",
                fontWeight: FontWeight.w700,
                fontSize: 20),
          ),
        ),
        TextButton(
            onPressed: () {
              // Functionality to navigate to sign up page (current page)
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => const SignUpPage()),
              );
            },
            child: const Text(
              'SIGN UP',
              style: TextStyle(
                  color: whiteColor,
                  fontFamily: "Urbanist",
                  fontWeight: FontWeight.w700,
                  fontSize: 20),
            )),
      ],
    );
  }
}
