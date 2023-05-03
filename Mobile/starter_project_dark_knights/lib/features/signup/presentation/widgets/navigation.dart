import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import '../screen/signup_page.dart';

class TopNavigateBar extends StatelessWidget {
  const TopNavigateBar({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final double screenHeight = MediaQuery.of(context).size.height;
    return Padding(
      padding: EdgeInsets.only(bottom: screenHeight * 0.03),
      child: Row(
        // crossAxisAlignment: CrossAxisAlignment.stretch,
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,

        children: [
          InkWell(
            onTap: () {
              // Functionality to navigate to login page
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => (const SignUpPage())),
              );
            },
            child: Text(
              'LOGIN',
              style: TextStyle(
                  color: whiteColor.withOpacity(0.3),
                  fontFamily: "Urbanist",
                  fontWeight: FontWeight.w700,
                  fontSize: screenHeight * 0.023),
            ),
          ),
          InkWell(
              onTap: () {
                // Functionality to navigate to sign up page (current page)
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const SignUpPage()),
                );
              },
              child: Text(
                'SIGN UP',
                style: TextStyle(
                    color: whiteColor,
                    fontFamily: "Urbanist",
                    fontWeight: FontWeight.w700,
                    fontSize: screenHeight * 0.023),
              )),
        ],
      ),
    );
  }
}
