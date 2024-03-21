import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:matador/features/feed/presentation/screen/home_page.dart';
import 'package:matador/injection/injection.dart';

import '../../../../core/utils/constants/global_variables.dart';
import '../bloc/login_bloc.dart';
import '../bloc/login_event.dart';
import '../bloc/login_state.dart';
import '../widgets/login/forgot_pass.dart';
import '../widgets/login/input_form_field.dart';
import '../widgets/login/login_signup.dart';
import '../widgets/login/logo.dart';
import '../widgets/login/rounded_button.dart';
import '../widgets/login/sign_in_with_your_account.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    final _emailController = TextEditingController();
    final _passwordController = TextEditingController();
    return GestureDetector(
      onTap: () {
        FocusScope.of(context).requestFocus(FocusNode());
      },
      child: Scaffold(
        resizeToAvoidBottomInset: false,
        body: BlocProvider(
          create: (_) => sl<LoginBloc>(),
          child: BlocBuilder<LoginBloc, LoginState>(
            builder: (context, state) {
              return Stack(
                children: [
                  SingleChildScrollView(
                    child: buildLogin(
                        height, width, _emailController, _passwordController),
                  ),
                  if (state is LoginLoadingState)
                    Center(child: CircularProgressIndicator()),
                ],
              );
            },
          ),
        ),
      ),
    );
  }

  Widget buildLogin(
      double height,
      double width,
      TextEditingController emailController,
      TextEditingController passwordController) {
    return Column(
      children: [
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
        BlocConsumer<LoginBloc, LoginState>(
          listener: (context, state) {
            if (state is LoginFailureState) {
              ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(content: Text(state.error)),
              );
            }

            if (state is LoginSuccessState) {
              Navigator.push(context,
                  MaterialPageRoute(builder: (context) => const HomePage()));
            }
            // Navigator.pushNamed(context, '/homepage', arguments: state.id);
          },
          builder: (context, state) => RoundedButton(
            width: width,
            height: height,
            pressed: () {
              BlocProvider.of<LoginBloc>(context).add(
                LoginButtonPressedEvent(
                  email: emailController.text,
                  password: passwordController.text,
                ),
              );
            },
          ),
        ),
        const ForgotPassword(),
      ],
    );
  }
}
