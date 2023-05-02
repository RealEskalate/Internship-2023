import 'package:flutter/material.dart';

// ignore: must_be_immutable
class Logo extends StatelessWidget {
  Logo({super.key});
  // ignore: non_constant_identifier_names
  String Link =
      "https://media.licdn.com/dms/image/D4E16AQGS-26jpTdk2w/profile-displaybackgroundimage-shrink_200_800/0/1671689947030?e=2147483647&v=beta&t=6y-EPCeib7vMuOKrklKkiVnqCw8KEH0q6VfJovmBb9A";

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: (54 / 812) * MediaQuery.of(context).size.height,
      width: (141 / 375) * MediaQuery.of(context).size.width,
      child: Image(
        image: NetworkImage(Link),
      ),
    );
  }
}
