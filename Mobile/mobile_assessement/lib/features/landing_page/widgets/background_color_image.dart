
import 'package:flutter/material.dart';

class BackGroundColorImage extends StatelessWidget {
  const BackGroundColorImage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Image(
      image: const AssetImage("assets/images/landing_page_bg.png"),
      fit: BoxFit.cover,
      width: MediaQuery.of(context).size.width,
      height: MediaQuery.of(context).size.height,
    );
  }
}
