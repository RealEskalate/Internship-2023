import 'package:dark_knights/core/utils/text_style.dart';
import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import 'log_in_button.dart';

class LogInForm extends StatelessWidget {
  const LogInForm({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
      const Text(
        "Welcome back",
        style: TextStyles.welcomeBack,
      ),
      SizedBox(height: MediaQuery.of(context).size.height * 0.012),
      const Text(
        "Sign in with your account",
        style: TextStyles.signIn,
      ),
      SizedBox(height: MediaQuery.of(context).size.height * 0.03),
      const Text(
        "Username",
        style: TextStyles.formFieldTextStyle,
      ),
      const TextField(
        decoration: InputDecoration(
          hintText: 'Jonathandavis@gmail.com',
          hintStyle: TextStyles.hintText,
        ),
      ),
      SizedBox(height: MediaQuery.of(context).size.height * 0.03),
      const Text(
        "Password",
        style: TextStyles.formFieldTextStyle,
      ),
      Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(
                hintText: '••••••',
                hintStyle: TextStyles.passwordTextFieldHint,
              ),
            ),
          ),
          TextButton(
            onPressed: () {},
            child: Text(
              "Show",
              style: TextStyles.showButton,
            ),
          ),
        ],
      ),
      SizedBox(height: MediaQuery.of(context).size.height * 0.2),
      LogInButton(),
      SizedBox(height: MediaQuery.of(context).size.height * 0.01),
      Row(mainAxisAlignment: MainAxisAlignment.center, children: [
        Text(
          "Forgot your password?",
          style: TextStyles.forgotPassword,
        ),
        SizedBox(width: MediaQuery.of(context).size.width * 0.02),
        Text(
          "Reset here",
          style: TextStyles.reset,
        ),
      ]),
    ]);
  }
}

