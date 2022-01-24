
fn main() {
    println!("{}",add_f64(2.0,8.0));
}

/// add two f64 numbers
#[no_mangle]
pub extern fn add_f64(num1: f64, num2: f64) -> f64 {
    num1 + num2
}

/// substract two two f64 numbers
/// floating point numbers are weird so we use this rounding trick
#[no_mangle]
pub extern fn sub_f64(num1: f64, num2: f64) -> f64 {
    ((num1 - num2)*1e5_f64).round()/1e5_f64
}

// multiply two f64 numbers
#[no_mangle]
pub extern fn multi_f64(num1: f64, num2: f64) -> f64 {
    num1 * num2
}

/// divide two f64 numbers
#[no_mangle]
pub extern fn div_f64(num1: f64, num2: f64) -> f64 {
    if num2 != 0_f64 {
        num1 / num2
    }
    else {
        panic!("bad number");
    }
}


#[cfg(test)]
pub mod tests{
    
    #[test]
    fn add_test1() {
        assert_eq!(crate::add_f64(2.0,8.0), 10.0);
    }

    #[test]
    fn add_test2(){
        assert_eq!(crate::add_f64(5.2, 3.1), 8.3)
    } 

    #[test]
    fn sub_test1(){
        assert_eq!(crate::sub_f64(10.0, 5.31), 4.69_f64)
    }

    #[test]
    fn sub_test2(){
        assert_eq!(crate::sub_f64(10.0, -5.31), 15.31_f64)
    }

    #[test]
    fn multi_test1(){
        assert_eq!(crate::multi_f64(15.0, 3.0), 45.0_f64)
    }

    #[test]
    fn multi_test2(){
        assert_eq!(crate::multi_f64(15.491, 3.13), 48.48683_f64)
    }

    #[test]
    #[should_panic]
    fn div_test1(){
        assert_eq!(crate::div_f64(10_f64, 0_f64), std::f64::INFINITY)
    }

    #[test]
    fn div_test2(){
        assert_eq!(crate::div_f64(15.30, 0.64), 23.90625_f64)
    }
}

