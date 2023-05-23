import 'package:flutter/material.dart';

import '../../../../core/utils/constants/global_variables.dart';
import '../bloc/login_bloc.dart';
import 'package:flutter/material.dart';
import '../bloc/login_bloc.dart';
import '../bloc/login_event.dart';
import '../widgets/login/forgot_pass.dart';
import '../widgets/login/input_form_field.dart';
import '../widgets/login/login_signup.dart';
import '../widgets/login/logo.dart';
import '../widgets/login/rounded_button.dart';
import '../widgets/login/sign_in_with_your_account.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    final _emailController = TextEditingController();
    final _passwordController = TextEditingController();
    // final LoginBloc _loginBloc;

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
        LoginSignupNavBar(
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
                  SizedBox(
                    width: width,
                    child: const Text(
                      'Welcome back',
                      style: TextStyle(
                          color: headingColor,
                          fontSize: 30,
                          fontFamily: 'Urbanist',
                          fontWeight: FontWeight.bold),
                    ),
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
                    const InputFormField(password: false),
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
                    const InputFormField(password: true),
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
          pressed: null,
        ),
        const ForgotPassword(),
      ]),
    );
  }
}
