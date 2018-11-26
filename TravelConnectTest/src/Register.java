import java.util.regex.Pattern;
import java.util.concurrent.TimeUnit;
import org.junit.*;
import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.Select;

public class Register {
  private WebDriver driver;
  private String baseUrl;
  private boolean acceptNextAlert = true;
  private StringBuffer verificationErrors = new StringBuffer();

  @Before
  public void setUp() throws Exception {
	  String path = "C:/Users/BlueBongo/Downloads/chromedriver.exe";
	  System.setProperty("webdriver.chrome.driver", path);
    driver = new ChromeDriver();
    baseUrl = "https://travelconnect.ddns.net/";
    driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
  }

  @Test
  public void testRegister() throws Exception {
    driver.get("http://travelconnect.ddns.net/Trip");
    driver.findElement(By.linkText("Register")).click();
    driver.findElement(By.id("Input_FirstName")).click();
    driver.findElement(By.id("Input_FirstName")).clear();
    driver.findElement(By.id("Input_FirstName")).sendKeys("asdf");
    Thread.sleep(1000);
    driver.findElement(By.id("Input_LastName")).clear();
    driver.findElement(By.id("Input_LastName")).sendKeys("asdf");
    Thread.sleep(1000);
    driver.findElement(By.id("Input_PhoneNumber")).clear();
    driver.findElement(By.id("Input_PhoneNumber")).sendKeys("867-5309");
    Thread.sleep(1000);
    driver.findElement(By.id("Input_Email")).clear();
    driver.findElement(By.id("Input_Email")).sendKeys("asdf");
    Thread.sleep(1000);
    driver.findElement(By.id("Input_Password")).clear();
    driver.findElement(By.id("Input_Password")).sendKeys("asdf");
    Thread.sleep(1000);
    driver.findElement(By.id("Input_ConfirmPassword")).clear();
    driver.findElement(By.id("Input_ConfirmPassword")).sendKeys("asdf");
    Thread.sleep(2000);
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Confirm password'])[1]/following::button[1]")).click();
    Thread.sleep(2000);
    driver.findElement(By.id("Input_Email")).click();
    driver.findElement(By.id("Input_Email")).clear();
    driver.findElement(By.id("Input_Email")).sendKeys("asdf@asdf.edu");
    Thread.sleep(1000);
    driver.findElement(By.id("Input_Password")).click();
    driver.findElement(By.id("Input_Password")).clear();
    driver.findElement(By.id("Input_Password")).sendKeys("3ed#ED");
    Thread.sleep(1000);
    driver.findElement(By.id("Input_ConfirmPassword")).clear();
    driver.findElement(By.id("Input_ConfirmPassword")).sendKeys("3ed#ED");
    Thread.sleep(1000);
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Confirm password'])[1]/following::button[1]")).click();
    Thread.sleep(2000);
  }

  @After
  public void tearDown() throws Exception {
    driver.quit();
    String verificationErrorString = verificationErrors.toString();
    if (!"".equals(verificationErrorString)) {
      fail(verificationErrorString);
    }
  }

  private boolean isElementPresent(By by) {
    try {
      driver.findElement(by);
      return true;
    } catch (NoSuchElementException e) {
      return false;
    }
  }

  private boolean isAlertPresent() {
    try {
      driver.switchTo().alert();
      return true;
    } catch (NoAlertPresentException e) {
      return false;
    }
  }

  private String closeAlertAndGetItsText() {
    try {
      Alert alert = driver.switchTo().alert();
      String alertText = alert.getText();
      if (acceptNextAlert) {
        alert.accept();
      } else {
        alert.dismiss();
      }
      return alertText;
    } finally {
      acceptNextAlert = true;
    }
  }
}
