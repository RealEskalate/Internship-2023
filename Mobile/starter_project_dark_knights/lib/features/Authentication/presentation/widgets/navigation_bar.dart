import 'package:flutter/material.dart';
import 'package:dark_knights/core/utils/text_style.dart';
import '../../../../core/utils/colors.dart';

class LoginSignUpNavigation extends StatelessWidget {
  const LoginSignUpNavigation({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.start,
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          "LOGIN",
          style: TextStyles.login,
        ),
        SizedBox(width: MediaQuery.of(context).size.width * 0.3),
        Text("SIGNUP", style: TextStyles.signUp),
      ],
    );
  }
}
