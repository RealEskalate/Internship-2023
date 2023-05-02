import 'package:flutter/material.dart';

import '../../../../core/utils/constants/global_variables.dart';
import '../widgets/forgot_password.dart';
import '../widgets/input_line.dart';
import '../widgets/login_signup.dart';
import '../widgets/logo.dart';
import '../widgets/rounded_button.dart';
import '../widgets/sign_in_with_your_account.dart';
import '../widgets/welcome_back.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: Column(children: [
        Padding(
          padding: EdgeInsets.only(top: height * 0.04, bottom: height * 0.04),
          child: Center(
            child: A2SVLogo(
              width: width,
              height: height,
            ),
          ),
        ),
        LoginSignup(
          width: width,
          height: height,
        ),
        Padding(
          padding: EdgeInsets.symmetric(horizontal: width * 0.11),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Column(
                children: [
                  WelcomeBack(
                    width: width,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(top: 15.0),
                    child: SignInWithYourAccount(
                      width: width,
                    ),
                  ),
                ],
              ),
              Padding(
                padding: EdgeInsets.symmetric(vertical: height * 0.05),
                child: Column(
                  children: [
                    SizedBox(
                        width: width,
                        child: const Text(
                          'username',
                          style: TextStyle(
                              color: secondaryColor,
                              fontStyle: FontStyle.italic,
                              fontFamily: 'Urbanist'),
                        )),
                    const InputLine(password: false),
                    SizedBox(
                      height: 0.02 * height,
                    ),
                    SizedBox(
                        width: width,
                        child: const Text(
                          'password',
                          style: TextStyle(
                              color: secondaryColor,
                              fontStyle: FontStyle.italic,
                              fontFamily: 'Urbanist'),
                        )),
                    const InputLine(password: true),
                  ],
                ),
              ),
            ],
          ),
        ),
        SizedBox(
          height: height * 0.1,
        ),
        RoundedButton(
          width: width,
          height: height,
        ),
        const ForgotPassword(),
      ]),
    );
  }
}
